function OnClick_CloseError(element) {
    
    element.parentNode.parentNode.className += " disabled"
}

window.onscroll = () => {
    let top = window.pageYOffset || document.documentElement.scrollTop
    let menuHeader = document.querySelector('#menuHeader')

    if (top >= 100) {
        menuHeader.classList.add('active')
    } else {
        menuHeader.classList.remove('active')
    }
}