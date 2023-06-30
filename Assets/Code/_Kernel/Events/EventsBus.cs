using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace Events {
   public class EventsBus {
      private const int _CAPACITY            = 16;
      private const int _SINGLETONS_CAPACITY = 8;

      private readonly Dictionary<Type, EcsFilter> _cachedFilters;
      private readonly Dictionary<Type, int>       _singletons;

      public EcsWorld World { get; }



      public EventsBus() {
         World          = new EcsWorld();
         _cachedFilters = new Dictionary<Type, EcsFilter>(_CAPACITY);
         _singletons    = new Dictionary<Type, int>(_SINGLETONS_CAPACITY);
      }

      public void Destroy() {
         _singletons.Clear();
         _cachedFilters.Clear();
         World.Destroy();
      }



      #region EventsSingleton

      public ref T NewEventSingleton<T>() where T : struct, ISingletonEvent {
         Type       type       = typeof(T);
         EcsPool<T> eventsPool = World.GetPool<T>();

         if (_singletons.TryGetValue(type, out int eventEntity)) return ref eventsPool.Get(eventEntity);

         eventEntity = World.NewEntity();
         _singletons.Add(type, eventEntity);
         return ref eventsPool.Add(eventEntity);
      }

      public bool HasEventSingleton<T>() where T : struct, ISingletonEvent => _singletons.ContainsKey(typeof(T));


      public bool HasEventSingleton<T>(out T eventBody) where T : struct, ISingletonEvent {
         bool hasEvent = _singletons.TryGetValue(typeof(T), out int eventEntity);
         eventBody = hasEvent ? World.GetPool<T>().Get(eventEntity) : default;
         return hasEvent;
      }


      public ref T GetEventBodySingleton<T>() where T : struct, ISingletonEvent {
         int        eventEntity = _singletons[typeof(T)];
         EcsPool<T> eventsPool  = World.GetPool<T>();
         return ref eventsPool.Get(eventEntity);
      }

      public void DestroyEventSingleton<T>() where T : struct, ISingletonEvent {
         Type type = typeof(T);

         if (!_singletons.TryGetValue(type, out int eventEntity)) return;

         World.DelEntity(eventEntity);
         _singletons.Remove(type);
      }

      #endregion


      #region Events

      public ref T NewEvent<T>() where T : struct, IEvent {
         int newEntity = World.NewEntity();
         return ref World.GetPool<T>().Add(newEntity);
      }

      private EcsFilter GetFilter<T>() where T : struct, IEvent {
         Type type = typeof(T);

         if (_cachedFilters.TryGetValue(type, out EcsFilter filter)) return filter;

         filter = World.Filter<T>().End();
         _cachedFilters.Add(type, filter);

         return filter;
      }

      public EcsFilter GetEventBodies<T>(out EcsPool<T> pool) where T : struct, IEvent {
         pool = World.GetPool<T>();
         return GetFilter<T>();
      }

      public bool HasEvents<T>() where T : struct, IEvent {
         EcsFilter filter = GetFilter<T>();
         return filter.GetEntitiesCount() != 0;
      }

      public void DestroyEvents<T>() where T : struct, IEvent {
         foreach (int eventEntity in GetFilter<T>()) {
            World.DelEntity(eventEntity);
         }
      }

      #endregion


      #region DestroyEventsSystem

      public DestroyEventsSystem GetDestroyEventsSystem(int capacity = 16) => new DestroyEventsSystem(this, capacity);

      public class DestroyEventsSystem : IEcsRunSystem {
         private readonly List<Action> _destructionActions;
         private readonly EventsBus    _eventsBus;

         public DestroyEventsSystem(EventsBus eventsBus, int capacity) {
            _eventsBus          = eventsBus;
            _destructionActions = new List<Action>(capacity);
         }

         public void Run(IEcsSystems systems) {
            foreach (Action action in _destructionActions) {
               action();
            }
         }

         public DestroyEventsSystem IncReplicant<TR>() where TR : struct, IEvent {
            _destructionActions.Add(() => _eventsBus.DestroyEvents<TR>());
            return this;
         }

         public DestroyEventsSystem IncSingleton<TS>() where TS : struct, ISingletonEvent {
            _destructionActions.Add(() => _eventsBus.DestroyEventSingleton<TS>());
            return this;
         }
      }

      #endregion
   }
}