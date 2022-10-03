const {expect} = require('chai');
const { carService } = require('./solution')

describe('Test', () => {
    describe('isItExpensive', () => {
        it ('happy path', () => {
            expect(carService.isItExpensive('Engine')).to.equal(`The issue with the car is more severe and it will cost more money`);
            expect(carService.isItExpensive('Transmission')).to.equal(`The issue with the car is more severe and it will cost more money`);
            expect(carService.isItExpensive('test')).to.equal(`The overall price will be a bit cheaper`);
        })
    })

    describe('discount', () => {
        it ('happy path', () => {
            expect(carService.discount(3, 100)).to.equal(`Discount applied! You saved ${100 * 0.15}$`);
            expect(carService.discount(8, 100)).to.equal(`Discount applied! You saved ${100 * 0.30}$`);
            expect(carService.discount(2, 100)).to.equal("You cannot apply a discount");
        })
        it('invalid input', () => {
            expect(() => carService.discount('3',100)).to.throw('Invalid input');
            expect(() => carService.discount(3,'100')).to.throw('Invalid input');
            expect(() => carService.discount('3','100')).to.throw('Invalid input');
        })
    })

    describe('partsToBuy', () =>{
        it ('happy path', () => {
            expect(carService.partsToBuy([
                { part: "blowoff valve",
                 price: 145 },
                { part: "coil springs",
                 price: 230 },
                {part: "injectors",
                 price: 120}],
                 ["blowoff valve",
                  "injectors"])).to.equal(265);
            expect(carService.partsToBuy([], ["blowoff valve","injectors"])).to.equal(0);
        })
        it('invalid input', () => {
            expect(() => carService.partsToBuy('', ["blowoff valve","injectors"])).to.throw('Invalid input');
            expect(() => carService.partsToBuy([
                { part: "blowoff valve",
                 price: 145 },
                { part: "coil springs",
                 price: 230 },
                {part: "injectors",
                 price: 120}], '')).to.throw('Invalid input');
            expect(() => carService.partsToBuy('', '')).to.throw('Invalid input');
            expect(() => carService.partsToBuy(1, '')).to.throw('Invalid input');
            expect(() => carService.partsToBuy('', 1)).to.throw('Invalid input');
        })
    })
});