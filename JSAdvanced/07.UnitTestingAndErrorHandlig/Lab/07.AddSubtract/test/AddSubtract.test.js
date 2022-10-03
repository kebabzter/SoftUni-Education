const {assert} = require('chai');
const createCalculator = require('../AddSubtract');

describe('Create calculator function test', () => {
    it('Everything should works', () => {
        let calc = createCalculator();
        calc.add(5);
        calc.subtract(1);
        
        assert.equal(calc.get(), 4);
    });

    it('Should works with parsed strings', () => {
        let calc = createCalculator();
        calc.add('5');
        calc.subtract('1');
        
        assert.equal(calc.get(), 4);
    });

    it('Should works without adding', () => {
        let calc = createCalculator();
        calc.subtract('1');
        
        assert.equal(calc.get(), -1);
    });

    it('Should works without actions', () => {
        let calc = createCalculator();
        
        assert.equal(calc.get(), 0);
    });

    it('Should throw NaN with everything else', () => {
        let calc = createCalculator();
        
        calc.add('s');
        assert.isNaN(calc.get());

        calc.add([]);
        assert.isNaN(calc.get());
   
        calc.add({});
        assert.isNaN(calc.get());
        
        calc.add(undefined);
        assert.isNaN(calc.get());
        
        calc.add(null);
        assert.isNaN(calc.get());

    });

    it('Math operations should not works', () => {
        let calc = createCalculator();
        calc.add(5);
        calc.subtract(1);
        
        assert.notEqual(calc.get(), 5);
    });

    it('Math operations should not works2', () => {
        let calc = createCalculator();
        calc.add(5);
        calc.value = 6;

        assert.equal(calc.get(), 5);
    });

    it('Should return object', () => {
        let calc = createCalculator();

        assert.equal(typeof(calc), 'object')
    });

    it('Should return number', () => {
        let calc = createCalculator();

        assert.equal(typeof(calc.get()), 'number')
    });

    it('Should has add, subtract and get properties', () => {
        let calc = createCalculator();

        assert.isTrue(calc.hasOwnProperty('add'));
        assert.isTrue(calc.hasOwnProperty('subtract'));
        assert.isTrue(calc.hasOwnProperty('get'));
        assert.isFalse(calc.hasOwnProperty('sum'));
    });
})