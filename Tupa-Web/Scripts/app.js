/*let close_button = document.querySelector('.close_button')
let errorMessage = document.querySelector('.error-message')

close_button.addEventListener('click', () => {
    errorMessage.className += " disabled"
})
*/
window.onscroll = () => {
    let top = window.pageYOffset || document.documentElement.scrollTop
    let menuHeader = document.querySelector('#menuHeader')

    if (top >= 100) {
        menuHeader.classList.add('active')
    } else {
        menuHeader.classList.remove('active')
    }
}