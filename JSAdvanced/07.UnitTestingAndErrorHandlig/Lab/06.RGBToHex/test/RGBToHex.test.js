const { assert } = require('chai');
const rgbToHexColor = require('../RGBToHex');

describe('RGBToHex function testing', () => {
    it('Should works', () => {
        assert.equal(rgbToHexColor(0,0,0), '#000000');
        assert.equal(rgbToHexColor(255,50,154), '#FF329A');
        assert.equal(rgbToHexColor(255,255,255), '#FFFFFF');
    });

    it('Should not works with number which are not in the range', () => {
        assert.equal(rgbToHexColor(-1, 1000, 256), undefined);
    });

    it('Should not works with one number that is not in the range', () => {
        assert.isUndefined(rgbToHexColor(-1, 1, 1));
        assert.isUndefined(rgbToHexColor(1, 256, 1));
        assert.isUndefined(rgbToHexColor(1, 1, 10000));
    });

    it('Should not works any other types', () => {
        assert.isUndefined(rgbToHexColor([], [], []));
        assert.isUndefined(rgbToHexColor({}, {}, {}));
        assert.isUndefined(rgbToHexColor('a', 'b', 'c'));
        assert.isUndefined(rgbToHexColor('1', '2', '3'));
        assert.isUndefined(rgbToHexColor(undefined, undefined, undefined));
        assert.isUndefined(rgbToHexColor(null, null, null));
        assert.isUndefined(rgbToHexColor([], {}, 'a'));
        assert.isUndefined(rgbToHexColor(undefined, null, '1'));
    });

    it('Should return string', () => {
        assert.equal(typeof(rgbToHexColor(1,1,1)), 'string');
    })
});