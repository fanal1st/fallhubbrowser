using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebOS.FallHub
{
    /// <summary>
    /// Flags used by INewWindowManager::EvaluateNewWindow. 
    /// These values are taken into account in the decision of whether to display a pop-up window.
    /// </summary>
    [Flags]
    enum UrlContext
    {
        /// <summary>
        /// No information Present
        /// </summary>
        None = 0x0,
        /// <summary>
        /// The page is unloading. This flag is set in response to the onbeforeunload and onunload events. 
        /// Some pages load pop-up windows when you leave them rather than when you enter. This flag is used to identify those situations.
        /// </summary>
        Unloading = 0x1,
        /// <summary>
        /// The call to INewWindowManager::EvaluateNewWindow is the result of a user-initiated action 
        /// (a mouse click or key press). Use this flag in conjunction with the NWMF_FIRST_USERINITED flag 
        /// to determine whether the call is a direct or indirect result of the user-initiated action.
        /// </summary>
        UserInited = 0x2,
        /// <summary>
        /// When NWMF_USERINITED is present, this flag indicates that the call to 
        /// INewWindowManager::EvaluateNewWindow is the first query that results from this user-initiated action. 
        /// Always use this flag in conjunction with NWMF_USERINITED.
        /// </summary>
        UserFirstInited = 0x4,
        /// <summary>
        /// The override key (ALT) was pressed. The override key is used to bypass the pop-up manager梐llowing 
        /// all pop-up windows to display梐nd must be held down at the time that INewWindowManager::EvaluateNewWindow is called. 
        /// </summary>
        OverrideKey = 0x8,
        /// <summary>
        /// The new window attempting to load is the result of a call to the showHelp method. Help is sometimes displayed in a separate window, 
        /// and this flag is valuable in those cases.
        /// </summary>
        ShowHelp = 0x10,
        /// <summary>
        /// The new window is a dialog box that displays HTML content.
        /// </summary>
        HtmlDialog = 0x20,
        /// <summary>
        /// Indicates that the EvaluateNewWindow method is being called through a marshalled Component Object Model (COM) proxy 
        /// from another thread. In this situation, the method should make a decision and return immediately without performing 
        /// blocking operations such as showing modal user interface (UI). Lengthy operations will cause the calling thread to 
        /// appear unresponsive.
        /// </summary>
        FromProxy = 0x40
    }

    public enum NavbarCommand
    {
        NavGo,
        Back,
        Forward,
        Refresh,
        Stop,
        Like,
        Comment,
        Tag,
        Login,
        Logout,
        Profile,
        Home,
        FullScreen,
        MutiView,
        SingleView
    }

    /// <summary>
    /// browser event command code
    /// </summary>
    public enum BrowSTACommand
    {
        UrlChanged,
        LoadCompeleted,
        LoadStarting,
        NewWindow,
        TitleChanged,
        StatusChanged
    }

    /// <summary>
    /// This enum represents the possible browser commands
    /// </summary>
    [Flags]
    enum BrowserCommands
    {
        /// <summary>
        /// Used when no commans are available
        /// </summary>
        None = 0,
        Home = 1,
        Search = 2,
        Back = 4,
        Forward = 8,
        Stop = 16,
        Reload = 32,
        Print = 64,
        PrintPreview = 128
    }

    /// <summary>
    /// Represents the filter level op the pop-up blocker
    /// </summary>
    enum PopupBlockerFilterLevel
    {
        /// <summary>
        /// No pop-ups are blocked
        /// </summary>
        None = 0,
        /// <summary>
        /// Pop-ups of secure sites are allowed
        /// </summary>
        Low,
        /// <summary>
        /// Most pop-ups are blocked, unless the Ctrl key is pressed
        /// </summary>
        Medium,
        /// <summary>
        /// All pop-ups are blocked, unless the Ctrl key is pressed
        /// </summary>
        High
    }

    /// <summary>
    /// sys state changed action flag used to trigger some method
    /// </summary>
    public enum SysEventCMD
    {
        Info,
        Error,


    }


}
