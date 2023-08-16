function countdown(elementName, minutes, seconds) {
    var element, endTime, hours, mins, msLeft, time;
  
    function twoDigits(n) {
      return n <= 9 ? "0" + n : n;
    }
  
    function updateTimer() {
      msLeft = endTime - Date.now();
      if (msLeft < 1000) {
        location.href = "/Home/Perdida";
      } else {
        time = new Date(msLeft);
        hours = time.getUTCHours();
        mins = time.getUTCMinutes();
        element.innerHTML =
          (hours ? hours + ":" + twoDigits(mins) : mins) +
          ":" +
          twoDigits(time.getUTCSeconds());
        setTimeout(updateTimer, time.getUTCMilliseconds() + 500);
      }
    }
    element = document.getElementById(elementName);
    endTime = localStorage.getItem("endTime");
    if (!endTime || hidden){
      // Si no hay tiempo de finalización almacenado, se establece uno nuevo
      endTime = Date.now() + 1000 * (60 * minutes + seconds) + 500;
      localStorage.setItem("endTime", endTime);
    } else {
      
      // Si hay un tiempo de finalización almacenado, se calcula el tiempo restante
      endTime = parseInt(endTime, 10);
    }
    updateTimer();
  }
  
  if(hidden){
    countdown("countdown", 00, 10);
  }
  
  countdown("countdown", 00, 10);
  