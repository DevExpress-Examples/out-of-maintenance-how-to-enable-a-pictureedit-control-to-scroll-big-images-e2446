# How to enable a PictureEdit control to scroll big images


<p>This example demonstrates how to enable a PictureEdit control to scroll images that don't fit into it. We have created a PictureEdit descendant and inserted scrollbars in it. Also we have added a Scrollable property indicating when scrollbars can be shown. It should be noted that scrollbars appear only when the SizeMode option is set to "Clip" because other values of SizeMode enable PictureEdit to fit the picture into its bounds in various ways. So when the Scrollable option is enabled SizeMode sets itself to the "Clip" value and on the contrary, when the ZoomMode option is set to a value other than "Clip" Scrollable disables itself.</p>

<br/>


