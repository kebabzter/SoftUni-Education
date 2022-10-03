const {assert} = require('chai');
const lookupChar = require('../CharLookUp');

describe('LookupChar function testing', () => {
    it ('Should works', () => {
        assert.equal(lookupChar('hello', 0), 'h');
        assert.equal(lookupChar('hello', 2), 'l');
        assert.equal(lookupChar('hello', 4), 'o');
    });

    it('Should return undefined', () => {
        assert.isUndefined(lookupChar({},0))
        assert.isUndefined(lookupChar([],0))
        assert.isUndefined(lookupChar(0,0))
        assert.isUndefined(lookupChar(undefined,0))
        assert.isUndefined(lookupChar(null,0))
        assert.isUndefined(lookupChar('hello',{}))
        assert.isUndefined(lookupChar('hello',[]))
        assert.isUndefined(lookupChar('hello',''))
        assert.isUndefined(lookupChar('hello',undefined))
        assert.isUndefined(lookupChar('hello',null))
        assert.isUndefined(lookupChar('hello',2.2))
    });

    it('Should return incorrect index', () => {
        assert.equal(lookupChar('hello', -1), 'Incorrect index');
        assert.equal(lookupChar('hello', 5), 'Incorrect index');
    });
})