let close_button = document.querySelector('.close_button')
let errorMessage = document.querySelector('.error-message')

console.log(errorMessage)

close_button.addEventListener('click', () => {
    errorMessage.className += " disabled"
})