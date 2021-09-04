const Carousel = (() => {
    const types = {
        'Opacity': 1,
        'Move': 2
    }

    let interfacePage = {
        carousel: document.querySelector('.carousel'),
        progress: document.querySelector('.slider_progress'),
        next: document.querySelectorAll('.slide__button--next'),
        prev: document.querySelectorAll('.slide__button--prev')
    }

    let lenghtCarousel = () => {
        return interfacePage.carousel.childNodes.length
    }

    let indexCarousel = () => {
        let indexInitial

        interfacePage.carousel.childNodes.forEach((element, index) => {
            if (element.className) {
                if (element.className == 'slide_inner initial') {    
                    indexInitial = index
                }
            }
        })

        return indexInitial
    }

    let resetProgressBall = () => {
        interfacePage.progress.childNodes.forEach(element => {
            element.className = ''
        })
    }

    let setup = (type, progress) => {
        let lenght = lenghtCarousel()
        let indexInitial = indexCarousel()

        if (progress) {
            for (let i = 0; i < Math.floor(lenght / 2); i++) {
                let divELement = document.createElement('div')
        
                interfacePage.progress.appendChild(divELement)
            }
        
            interfacePage.progress.childNodes[Math.floor(indexInitial / 2) + 1].className = 'target'
        }

        // EventListeners
        if (type == types.Opacity) {
            interfacePage.next.forEach(element => {
                element.addEventListener('click', nextMovimentOpacity)  
            })
            interfacePage.prev.forEach(element => {   
                element.addEventListener('click', prevMovimentOpacity)
            })
        } else if (type == types.Move) {
            interfacePage.next.forEach(element => {
                element.addEventListener('click', nextMovimentMove)  
            })
            interfacePage.prev.forEach(element => {   
                element.addEventListener('click', prevMovimentMove)
            })
        }
    }

    let nextMovimentMove = () => {
        interfacePage.carousel.scrollTo(400 + interfacePage.carousel.scrollLeft, 0);
    }

    let prevMovimentMove = () => {
        interfacePage.carousel.scrollTo(interfacePage.carousel.scrollLeft - 400, 0);
    }

    let nextMovimentOpacity = (progress) => {
        let lenght = lenghtCarousel()
        let indexInitial = indexCarousel()

        if (lenght > indexInitial + 2) {
            interfacePage.carousel.childNodes[indexInitial].className = 'slide_inner'
            interfacePage.carousel.childNodes[indexInitial + 2].className = 'slide_inner initial'

            if (progress) {
                resetProgressBall()

                interfacePage.progress.childNodes[Math.floor(indexInitial / 2) + 2].className = 'target'
            }
        }
    }

    let prevMovimentOpacity = (progress) => {
        let indexInitial = indexCarousel()

        if (0 <= indexInitial - 2) {
            interfacePage.carousel.childNodes[indexInitial].className = 'slide_inner'
            interfacePage.carousel.childNodes[indexInitial - 2].className = 'slide_inner initial'

            if (progress) {
                resetProgressBall()

                interfacePage.progress.childNodes[Math.floor(indexInitial / 2)].className = 'target'
            }
        }
    }

    return {
        types: types,

        Setup: (type, progress) => {
            return setup(type, progress)
        },
    }
})()