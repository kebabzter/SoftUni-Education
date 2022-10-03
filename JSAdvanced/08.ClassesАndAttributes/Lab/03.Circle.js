class Circle {
    constructor(radius) {
        this.radius = radius;
    }

    get diameter() {
        return this.radius * 2;
    }

    set diameter(value) {
        this.radius = value / 2;
        return value;
    }

    get area() {
        return Math.PI * this.radius * this.radius;
    }
}