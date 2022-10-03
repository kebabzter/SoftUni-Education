const isSymmetric = require('../CheckForSymmetry');
const { assert } = require('chai');

describe('Array symmetry', () => {
    it('Should works with symmetric numbers', () => {
        assert.equal(isSymmetric([1,2,1]), true);
    });

    it('Should not works with non symmetric numbers', () => {
        assert.equal(isSymmetric([1,2,2]), false)
    })

    it('Should works with symmetric strings', () => {
        assert.equal(isSymmetric(['pes', 'g', 'pes']), true);
    })

    it('Should not works with different types', () => {
        assert.equal(isSymmetric([1, '1']), false);
    })

    it('Should not works with any input that isnt of the correct type', () => {
        assert.isNotTrue(isSymmetric({}));
        assert.isNotTrue(isSymmetric('s'));
        assert.isNotTrue(isSymmetric(0));
        assert.isNotTrue(isSymmetric(undefined));
        assert.isNotTrue(isSymmetric(null));
    })
})