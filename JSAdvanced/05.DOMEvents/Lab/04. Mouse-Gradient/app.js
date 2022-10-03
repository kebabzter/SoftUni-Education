function attachGradientEvents() {
    let gradient = document.getElementById("gradient");
    gradient.addEventListener('mousemove', gradientMove);
    gradient.addEventListener('mouseout', gradientOut);

    function gradientMove(ev) {
        let power = ev.offsetX / (ev.target.clientWidth - 1);
        power = Math.trunc(power * 100);
        document.getElementById("result").textContent = power + '%';
    }

    function gradientOut(ev){
        document.getElementById("result").textContent = "";
    }
}