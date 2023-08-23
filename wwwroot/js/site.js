const timerElement = document.getElementById('timer');
const timerTextElement = document.getElementById('timer-text');

let remainingTime = parseInt(localStorage.getItem('remainingTime')) || 15;
let countdownInterval;

function startCountdown() {
    countdownInterval = setInterval(() => {
        remainingTime--;

        if (remainingTime <= 5) {
            timerElement.classList.add('expired');
        }

        updateTimerDisplay();

        if (remainingTime <= 0) {
            clearInterval(countdownInterval);
            localStorage.removeItem('remainingTime');
            const actionUrl = timerElement.getAttribute('data-action-url');
            window.location.href = actionUrl; // Redirige a la página de respuesta
        }
    }, 1000);
}

function updateTimerDisplay() {
    timerTextElement.textContent = remainingTime;
}

function resetTimer() {
    remainingTime = 15;
    updateTimerDisplay();
    localStorage.removeItem('remainingTime');
}

// Check if it's the response or index page
if (window.location.href.includes('Respuesta')) {
    resetTimer();
} else if (window.location.href.includes('Index')) {
    resetTimer();
} else if (window.location.href.includes('Juego')) {
    timerElement.style.display = 'block'; // Mostrar el temporizador en la vista de juego
    startCountdown();
}

window.onbeforeunload = () => {
    if (!window.location.href.includes('Juego')) {
        localStorage.setItem('remainingTime', remainingTime.toString());
    }
};
