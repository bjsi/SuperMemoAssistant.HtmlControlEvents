using mshtml;
using SuperMemoAssistant.Extensions;
using SuperMemoAssistant.Interop.SuperMemo.Content.Controls;
using SuperMemoAssistant.Interop.SuperMemo.Core;
using SuperMemoAssistant.Services;
using SuperMemoAssistant.Sys.Remoting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;

namespace HTMLControlEvents
{
    public enum EventType
    {

        onkeydown,
        onclick,
        ondblclick,
        onkeypress,
        onkeyup,
        onmousedown,
        onmousemove,
        onmouseout,
        onmouseover,
        onmouseup,
        onselectstart,
        onbeforecopy,
        onbeforecut,
        onbeforepaste,
        oncontextmenu,
        oncopy,
        oncut,
        ondrag,
        ondragend,
        ondragenter,
        ondragleave,
        ondragover,
        ondrop,
        onfocus,
        onlosecapture,
        onpaste,
        onpropertychange,
        onreadystatechange,
        onresize,
        onactivate,
        onbeforedeactivate,
        oncontrolselect,
        ondeactivate,
        onmouseenter,
        onmouseleave,
        onmove,
        onmoveend,
        onmovestart,
        onpage,
        onresizeend,
        onresizestart,
        onfocusin,
        onfocusout,
        onmousewheel,

            // { "onafterupdate" }
            // { "onbeforeupdate" }
            // { "ondataavailable" }
            // { "ondatasetchanged" }
            // { "ondatasetcomplete" }
            // { "ondblclick" }
            // { "ondragstart" }
            // { "onerrorupdate" }
            // { "onfilterchange" }
            // { "onhelp" }
            // { "onrowenter" }
            // { "onrowexit" }
            // { "onbeforeeditfocus" }
            // { "onlayoutcomplete" }
            // { "onblur" () => BlurHandler() },

            // { "onrowsdelete" }
            // { "onrowsinserted" }
            // { "onlayoutcomplete" }

    }

    public class HTMLDocEvent
    {
        public EventType Type { get; set; }
        public Func<IControl, bool> ControlSelector { get; set; }
        public Func<IHTMLElement2, bool> IHTMLElementSelector { get; set; }

        public HTMLDocEvent(EventType @event, Func<IControl, bool> controlSelector = null, Func<IHTMLElement2, bool> elementSelector = null)
        {
            this.Type = @event;
            this.ControlSelector = controlSelector;
            this.IHTMLElementSelector = elementSelector;
        }
    }

    public partial class HTMLControlEvents
    {

        public event EventHandler<HTMLControlEventArgs> OnKeyDownEvent;
        public event EventHandler<HTMLControlEventArgs> OnClickEvent;
        public event EventHandler<HTMLControlEventArgs> OnFocusedEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseOverEvent;
        public event EventHandler<HTMLControlEventArgs> OnKeyPressEvent;
        public event EventHandler<HTMLControlEventArgs> OnKeyUpEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseDownEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseMoveEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseOutEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseUpEvent;
        public event EventHandler<HTMLControlEventArgs> OnSelectStartEvent;
        public event EventHandler<HTMLControlEventArgs> OnBeforeCopyEvent;
        public event EventHandler<HTMLControlEventArgs> OnBeforeCutEvent;
        public event EventHandler<HTMLControlEventArgs> OnBeforePasteEvent;
        public event EventHandler<HTMLControlEventArgs> OnContextMenuEvent;
        public event EventHandler<HTMLControlEventArgs> OnCopyEvent;
        public event EventHandler<HTMLControlEventArgs> OnCutEvent;
        public event EventHandler<HTMLControlEventArgs> OnDragEvent;
        public event EventHandler<HTMLControlEventArgs> OnDragEnterEvent;
        public event EventHandler<HTMLControlEventArgs> OnDragEndEvent;
        public event EventHandler<HTMLControlEventArgs> OnDragLeaveEvent;
        public event EventHandler<HTMLControlEventArgs> OnDragOverEvent;
        public event EventHandler<HTMLControlEventArgs> OnDropEvent;
        public event EventHandler<HTMLControlEventArgs> OnFocusEvent;
        public event EventHandler<HTMLControlEventArgs> OnLoseCaptureEvent;
        public event EventHandler<HTMLControlEventArgs> OnPasteEvent;
        public event EventHandler<HTMLControlEventArgs> OnPropertyStateChangeEvent;
        public event EventHandler<HTMLControlEventArgs> OnReadyStateChangeEvent;
        public event EventHandler<HTMLControlEventArgs> OnResizeEvent;
        public event EventHandler<HTMLControlEventArgs> OnActivateEvent;
        public event EventHandler<HTMLControlEventArgs> OnBeforeDeactivateEvent;
        public event EventHandler<HTMLControlEventArgs> OnControlSelectEvent;
        public event EventHandler<HTMLControlEventArgs> OnDeactivateEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseEnterEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseLeaveEvent;
        public event EventHandler<HTMLControlEventArgs> OnMoveEvent;
        public event EventHandler<HTMLControlEventArgs> OnMoveEndEvent;
        public event EventHandler<HTMLControlEventArgs> OnMoveStartEvent;
        public event EventHandler<HTMLControlEventArgs> OnPageEvent;
        public event EventHandler<HTMLControlEventArgs> OnResizeEndEvent;
        public event EventHandler<HTMLControlEventArgs> OnResizeStartEvent;
        public event EventHandler<HTMLControlEventArgs> OnFocusInEvent;
        public event EventHandler<HTMLControlEventArgs> OnFocusOutEvent;
        public event EventHandler<HTMLControlEventArgs> OnMouseWheelEvent;

    }

    public partial class HTMLControlEvents
    {
        private Dictionary<EventType, EventHandler<HTMLControlEventArgs>> EventMap => new Dictionary<EventType, EventHandler<HTMLControlEventArgs>>
        {
            { EventType.onkeydown,              OnKeyDownEvent },
            { EventType.onclick,                OnClickEvent },
            { EventType.onmouseover,            OnMouseOverEvent },
            { EventType.onkeypress,             OnKeyPressEvent },
            { EventType.onkeyup,                OnKeyUpEvent },
            { EventType.onmousedown,            OnMouseDownEvent },
            { EventType.onmousemove,            OnMouseMoveEvent },
            { EventType.onmouseout,             OnMouseOutEvent },
            { EventType.onmouseup,              OnMouseUpEvent },
            { EventType.onselectstart,          OnSelectStartEvent },
            { EventType.onbeforecopy,           OnBeforeCopyEvent },
            { EventType.onbeforecut,            OnBeforeCutEvent },
            { EventType.onbeforepaste,          OnBeforePasteEvent },
            { EventType.oncontextmenu,          OnContextMenuEvent },
            { EventType.oncopy,                 OnCopyEvent },
            { EventType.oncut,                  OnCutEvent },
            { EventType.ondrag,                 OnDragEvent },
            { EventType.ondragend,              OnDragEndEvent },
            { EventType.ondragenter,            OnDragEnterEvent },
            { EventType.ondragleave,            OnDragLeaveEvent },
            { EventType.ondragover,             OnDragOverEvent },
            { EventType.ondrop,                 OnDropEvent },
            { EventType.onfocus,                OnFocusEvent },
            { EventType.onlosecapture,          OnLoseCaptureEvent },
            { EventType.onpaste,                OnPasteEvent },
            { EventType.onpropertychange,       OnPropertyStateChangeEvent },
            { EventType.onreadystatechange,     OnReadyStateChangeEvent },
            { EventType.onresize,               OnResizeEvent },
            { EventType.onactivate,             OnActivateEvent },
            { EventType.onbeforedeactivate,     OnBeforeDeactivateEvent },
            { EventType.oncontrolselect,        OnControlSelectEvent },
            { EventType.ondeactivate,           OnDeactivateEvent },
            { EventType.onmouseenter,           OnMouseEnterEvent },
            { EventType.onmouseleave,           OnMouseLeaveEvent },
            { EventType.onmove,                 OnMoveEvent },
            { EventType.onmoveend,              OnMoveEndEvent },
            { EventType.onmovestart,            OnMoveStartEvent },
            { EventType.onpage,                 OnPageEvent },
            { EventType.onresizeend,            OnResizeEndEvent },
            { EventType.onresizestart,          OnResizeStartEvent },
            { EventType.onfocusin,              OnFocusInEvent },
            { EventType.onfocusout,             OnFocusOutEvent },
            { EventType.onmousewheel,           OnMouseWheelEvent }
        };

        public List<HTMLDocEvent> Events { get; set; }

        public HTMLControlEvents(List<HTMLDocEvent> events)
        {
            this.Events = events;
            Svc.SM.UI.ElementWdw.OnElementChanged += new ActionProxy<SMDisplayedElementChangedArgs>(OnElementChanged);
        }

        private void OnElementChanged(SMDisplayedElementChangedArgs obj)
        {
            SubscribeToHtmlDocEvents();
        }

        private void SubscribeToHtmlDocEvents()
        {
            if (Events == null || Events.Count == 0)
                return;

            var ctrlGroup = Svc.SM.UI.ElementWdw.ControlGroup;
            if (ctrlGroup == null)
                return;

            for (int i = 0; i < ctrlGroup.Count; i++)
            {
                var htmlCtrl = ctrlGroup[i]?.AsHtml();
                var htmlDoc = htmlCtrl?.GetDocument();
                var body = htmlDoc?.body;
                if (body == null)
                    continue;

                foreach (var htmlDocEvent in Events)
                {
                    try
                    {
                        var type = htmlDocEvent.Type;
                        if (EventMap.TryGetValue(type, out var normalEvent))
                        {
                            var comEventObj = new GenericHtmlDocEventHandler(normalEvent);
                            ((IHTMLElement2)body).attachEvent(nameof(type), comEventObj);
                        }
                    }
                    catch (Exception) { }
                }
            }
        }
    }


    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class GenericHtmlDocEventHandler : HTMLControlEvent
    {
        public int HTMLControlIdx { get; }
        public EventHandler<HTMLControlEventArgs> EventHandler { get; }

        public GenericHtmlDocEventHandler(EventHandler<HTMLControlEventArgs> eventHandler)
        {
            this.EventHandler = eventHandler;
        }

        [DispId(0)]
        public void handler(IHTMLEventObj e)
        {
            if (EventHandler != null)
            {
                var args = new HTMLControlEventArgs(e, HTMLControlIdx);
                EventHandler(this, args);
            }
        }
    }

    public interface HTMLControlEvent
    {
        int HTMLControlIdx { get; }
        void handler(IHTMLEventObj e);
    }

    public class HTMLControlEventArgs : RoutedEventArgs
    {
        public IHTMLEventObj EventObj { get; set; }
        public int HTMLControlIdx { get; set; }
        public HTMLControlEventArgs(IHTMLEventObj EventObj, int HTMLControlIdx)
        {
            this.EventObj = EventObj;
            this.HTMLControlIdx = HTMLControlIdx;
        }
    }

}
