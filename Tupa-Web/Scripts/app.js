function OnClick_CloseError(element) {    
    element.parentNode.parentNode.className += " disabled"

    setTimeout(() => {
        element.parentNode.parentNode.remove()
    }, 300)
}