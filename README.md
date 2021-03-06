# Notes on HTMLControl IHTMLDocument events and methods in SuperMemo / SMA

## General
- You can cast HTML objects between many different interfaces
	+ eg. IHTMLDocument, IHTMLDocument2, ..3, ..4, ... etc.
- All SuperMemo HTML element tag names are in caps
- Stuff added to the references section gets deleted on element change.
	+ Could use the area under the references to place buttons / other elements you don't want to persist.
- Wrap event related code in a try-catch block that catches this error that occasionly gets thrown:

	`Unhandled Exception: System.UnauthorizedAccessException: Access is denied. (Exception from HRESULT: 0x80070005 (E_ACCESSDENIED)) at mshtml.HTMLBodyClass.IHTMLElement2_attachEvent(String event, Object pdisp)`
	
- If you want access to an IHTMLDocument object's parentWindow, you must access it via the dispatcher, otherwise you get an exception:

```cs
     
      Application.Current.Dispatcher.Invoke(() =>
      {
        var window = htmlDoc.parentWindow;
        // your code here
      });
 ```

## Events
### `onkeydown`
- Status: Works. 
	+ Event fires when you press the keyboard while the HTMLControl is focused in edit mode.
	+ You can cancel sending the input to the IHTMLControl by setting the returnValue property of the IHTMLEventObj to false.
	+ Failed to restrict keypress / keydown / keyup to a single span.

### `onclick`
- Status: Mostly working
	+ Creating a button element and attaching to the event didn't work so well - the fact that the HTMLControl is a contenteditable HTML Document interferes with button clicking.
	+  Adding an onclick event to every element will fire the event when you click anywhere on the HTMLControl.
	+ Can be restricted to single elements.
- Tasks:
	+ [ ] Test adding a handler for the event to the root node of the document.

### `onmouseover`
- Status: Working
	+ The event gets fired even if the HTMLControl isn't focused in edit mode.
	+ This can be restricted to certain parts of the DOM (See MouseoverHints for an example)

### `onkeypress`
- Status: Working
	+ Doesn't capture backspace

### `onkeyup`
- Status: Working

### `onmousedown`
- Status: Working
	+ Events fired when I added the event to every element.

### `oncontextmenu`
- Status: Working
	+ Events fired when you right click on an HTMLControl to open a menu
	+ Also fired when you press Shift+F10 to open a menu.

### `oncontrolselect`
- Status: Working
	+ Event fires if you create a control element like a button inside an IHTMLControl and select it.
	
## Methods
- TODO
