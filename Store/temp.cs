// using Fluxor;
// using System.Collections.Generic;
// using System.Linq;
// using System.Reflection;

// [AttributeUsage(AttributeTargets.Method)]
// public class ExtensionMethodAttribute : Attribute { }

// [AttributeUsage(AttributeTargets.Method)]
// public class ReducerMethodAttribute : Attribute { }



// public class GenericState<TState> where TState : new()
// {
//     // Generate the reducer methods using reflection
//     private static Dictionary<Type, MethodInfo> _reducerMethods =
//         typeof(TState).GetMethods(BindingFlags.Static | BindingFlags.Public)
//             .Where(m => m.GetCustomAttribute<ReducerMethodAttribute>() != null)
//             .ToDictionary(m => m.GetParameters()[1].ParameterType, m => m);

//     // Generate the extension methods using reflection
//     private static Dictionary<Type, MethodInfo> _extensionMethods =
//         typeof(TState).GetMethods(BindingFlags.Static | BindingFlags.Public)
//             .Where(m => m.GetCustomAttribute<ExtensionMethodAttribute>() != null)
//             .ToDictionary(m => m.GetParameters()[0].ParameterType, m => m);

//     // Generate the feature state class using reflection
//     public class FeatureState : Feature<TState>
//     {
//         public override string GetName() => typeof(TState).Name;

//         protected override TState GetInitialState() => new TState();
//     }

//     public static void Dispatch(Action<TState> action)
//     {
//         // Dispatch the action to the appropriate reducer method
//         var actionType = action.Method.GetParameters()[1].ParameterType;
//         if (_reducerMethods.TryGetValue(actionType, out var reducerMethod))
//         {
//             var state = Store.GetState<TState>();
//             var newState = (TState)reducerMethod.Invoke(null, new object[] { state, action });
//             Store.SetState(newState);
//         }
//     }

//     public static void Dispatch<TAction>(TAction action)
//     {
//         // Dispatch the action to the appropriate extension method
//         var actionType = action.GetType();
//         if (_extensionMethods.TryGetValue(actionType, out var extensionMethod))
//         {
//             var state = Store.GetState<TState>();
//             extensionMethod.Invoke(null, new object[] { state, action });
//         }
//     }

// }

// // Define the state class with no additional code
// public record SideBarState
// {
//     public bool isOpen { get; set; }
// }

// // Define the action classes with the ExtensionMethod attribute
// [ExtensionMethod]
// public record ToggleSideBarAction { }

// [ExtensionMethod]
// public record SetSideBarAction { public bool isOpen { get; init; } }

// // Define the reducer methods with the ReducerMethod attribute
// public static class SideBarReducers
// {
//     [ReducerMethod]
//     public static SideBarState OnToggleSideBar(SideBarState state, ToggleSideBarAction action) => state with { isOpen = !state.isOpen };

//     [ReducerMethod]
//     public static SideBarState OnSetSideBar(SideBarState state, SetSideBarAction action) => state with { isOpen = action.isOpen };
// }

// // Use the generic state class to handle dispatching and state management
// public class SideBarStateManager : GenericState<SideBarState>
// {
//     // Extension methods are automatically generated and can be used directly
//     public static void ToggleSidebar(this IState<SideBarState> state) => Dispatch(new ToggleSideBarAction());
//     public static void SetSideBar(this IState<SideBarState> state, bool isOpen) => Dispatch(new SetSideBarAction { isOpen = isOpen });
// }