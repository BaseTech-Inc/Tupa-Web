function OnClick_CloseError(element) {    
    element.parentNode.parentNode.className += " disabled"

    setTimeout(() => {
        element.parentNode.parentNode.remove()
    }, 300)
}

function toogleResponsiveMenu() {
    let responsiveMenu = document.querySelector('#responsive_menu')

    responsiveMenu.classList.toggle('disabled')
}