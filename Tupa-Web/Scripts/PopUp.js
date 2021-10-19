function OnClickPopUp(document, event) {
    if (document.children[0].contains(event.target)){
        // Click in box
    } else{
        // Clicked outside the box
        document.classList.toggle('disabled')
    }
}