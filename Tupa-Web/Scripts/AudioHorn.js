const AudioHorn = (() => {
    let setup = (element) => {
        let audio = new Audio('/Content/Audios/clown-horn.mp3');
        let playAudio = element;

        playAudio.addEventListener('click', () => {
            playAudio.classList.remove('press');
            if (audio.paused) {
                audio.play();
            } else {
                audio.currentTime = 0;
            }

            playAudio.classList.add('press');

            setTimeout(() => {
                playAudio.classList.remove('press');
            }, 300);
        })
    }

    return {
        Setup: (element) => {
            return setup(element)
        }
    }
})()