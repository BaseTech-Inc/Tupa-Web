const TermsPrivacy = (() => {
    let interfacePage = {
        list: document.querySelector('.list')
    }

    let alterTarget = () => {
        let listItems = []

        interfacePage.list.childNodes.forEach(item => {
            if (item.className === 'list-item target' ||
                item.className === 'list-item') {
                    listItems.push(item)
            }
        })

        document.addEventListener('scroll', () => {
            let indexList

            listItems.forEach((item, index) => {
                if (item.offsetTop - item.style.height - 150 <= window.pageYOffset) {
                    item.className = 'list-item target'

                    indexList = index
                } else {
                    item.className = 'list-item'
                }
            })

            listItems.forEach((item, index) => {
                if (indexList != index) {
                    item.className = 'list-item'
                }
            })
        })
    }


    return {
        AlterTarget: () => {
            return alterTarget()
        }
    }
})()