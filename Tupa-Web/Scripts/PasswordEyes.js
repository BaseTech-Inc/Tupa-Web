const PasswordEyes = (() => {
    let PasswordEyesEvent = (object) => {
        let input = object.parentNode.querySelector('input')

        input.type = input.type == "password" ? "text" : "password"
    }

    return {
        PasswordEyesEvent
    }
})()