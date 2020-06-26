# Notes on HTMLControl IHTMLDocument events and methods in SuperMemo / SMA

## Events
### `onkeydown`
- Status: Works.
    + Event fires when you press the keyboard while the HTMLControl is focused in edit mode.
    + Test Notes: Added onkeydown event handler to `IHTMLDocument2.body` node.
- Tasks:
    + [ ] Test whether the event can be restricted to a certain area of the active IHTMLControl, eg. the references.

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
- Tasks:
    + [ ] Check whether it can be restricted to certain elements and areas of the HTMLControl.

### `onkeypress`
- TODO

### `onkeyup`
- TODO

### `onmousedown`
- Status: Working
    + Events fired when I added the event to every element.

## Methods
- TODO
