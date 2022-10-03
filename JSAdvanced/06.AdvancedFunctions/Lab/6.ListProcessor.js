function solve(input) {
    let result = {
        list: [],
        add(text) {
            this.list.push(text);
        },
        remove(text) {
            this.list = this.list.filter(x => x != text);
        },
        print() {
            console.log(this.list.join(','));
        }
    }

    for (const args of input) {
        let splittedArgs = args.split(' ')
        let cmd = splittedArgs[0];
        let text = splittedArgs[1];

        if (cmd == 'add') {
            result.add(text)
        } else if (cmd == 'remove') {
            result.remove(text);
        } else if (cmd == 'print') {
            result.print();
        }
    }
}

solve(['add pesho', 'add george', 'add peter', 'remove peter', 'print'])