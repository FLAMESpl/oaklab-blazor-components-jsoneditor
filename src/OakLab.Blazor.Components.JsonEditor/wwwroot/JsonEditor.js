window.oaklabJsonEditor = {
    handleOnInputEvent: async function (args) {
        const currentRange = document.getSelection().getRangeAt(0);
        const start = currentRange.startOffset;
        const container = currentRange.startContainer;

        await args.target.dotnetJsonEditor.invokeMethodAsync(
            "OnDocumentChanged",
            {
                fullText: args.target.innerText
            });

        currentRange.setStart(container, start);
    },
    registerOnInputEvent: function (element, dotnetJsonEditor) {
        element.dotnetJsonEditor = dotnetJsonEditor;
        element.addEventListener("input", oaklabJsonEditor.handleOnInputEvent);
    },
    unregisterOnInputEvent: function(element) {
        element.dotnetJsonEditor = undefined;
        element.removeEventListener("input", oaklabJsonEditor.handleOnInputEvent);
    }
}
