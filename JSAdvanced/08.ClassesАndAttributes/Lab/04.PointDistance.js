class Point {
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }

    static distance(a, b) {
        let xDistance = Math.abs(b.x - a.x);
        let yDistance = Math.abs(b.y - a.y);

        return Math.sqrt(xDistance ** 2 + yDistance ** 2);
    }
}