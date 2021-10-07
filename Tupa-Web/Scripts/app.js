function OnClick_CloseError(element) {    
    element.parentNode.parentNode.className += " disabled"

    setTimeout(() => {
        element.parentNode.parentNode.remove()
    }, 300)
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