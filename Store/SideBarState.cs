using Fluxor;

public record SideBarState
{
    public bool isOpen { get; set; }
}

public record ToggleSideBarAction { }
public record SetSideBarAction { public bool isOpen { get; init; } }

public static class SideBarReducers
{
    [ReducerMethod]
    public static SideBarState OnToggleSideBar(SideBarState state, ToggleSideBarAction action) => state with { isOpen = !state.isOpen };
    [ReducerMethod]
    public static SideBarState OnSetSideBar(SideBarState state, SetSideBarAction action) => state with { isOpen = action.isOpen };
}


public class SideBarFeatureState : Feature<SideBarState>
{
    public override string GetName() => nameof(SideBarState);
    protected override SideBarState GetInitialState() => new SideBarState { isOpen = false };
}

// this allows the convenience of calling these methods on the state object to dispatch, rather than having to inject the dispatcher and manually dispatch
public static class SideBarStateExtensions
{
    public static Action ToggleSidebar(this IState<SideBarState> state) => () => FluxorDispatch.Dispatch(new ToggleSideBarAction());
    public static Action SetSideBar(this IState<SideBarState> state, bool isOpen) => () => FluxorDispatch.Dispatch(new SetSideBarAction { isOpen = isOpen });
}

