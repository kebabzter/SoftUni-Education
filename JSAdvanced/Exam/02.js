class SmartHike{
    constructor(username){
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal(peak,altitude){
        if (this.goals[peak] != undefined) {
            return `${peak} has already been added to your goals`;
        }

        this.goals[peak] = altitude;
        return `You have successfully added a new goal - ${peak}`;
    }

    hike(peak,time,difficultyLevel){

        const neededResourses = time * 10;;

        if (this.resources <= 0) {
            return "You don't have enough resources to start the hike";
        }

        if(this.goals[peak] == undefined){
            throw new Error(`${peak} is not in your current goals`);
        }

        if(this.resources - neededResourses < 0){
            return "You don't have enough resources to complete the hike";
        }

        this.resources -= neededResourses;
        this.listOfHikes.push({
            peak: peak,
            time: time,
            difficultyLevel: difficultyLevel
        });

        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }

    rest(time){
        this.resources += time * 10;
        if (this.resources > 100) {
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`;
        }

        return `You have rested for ${time} hours and gained ${time*10}% resources`;
    }

    showRecord(criteria){
        if (this.listOfHikes.length == 0) {
            return `${this.username} has not done any hiking yet`;
        }

        if (criteria == 'all') {
            let foundHikes = this.listOfHikes;
            let hikes = [];
            for (let index = 0; index < foundHikes.length; index++) {
                let currHike = foundHikes[index];
                hikes.push(`${this.username} hiked ${currHike.peak} for ${currHike.time} hours`);      
            }
            let hikesRow = hikes.join('\n');
            return[
                'All hiking records:',
                hikesRow
            ].join('\n')
        }

        let hikes = this.listOfHikes.filter(obj => obj.difficultyLevel == criteria);

        if (hikes.length == 0) {
            return `${this.username} has not done any ${criteria} hiking yet`;
        }

        const sortedHikes = hikes.sort((a, b) => a.time - b.time);

        return `${this.username}'s best ${criteria} hike is ${sortedHikes[0].peak} peak, for ${sortedHikes[0].time} hours`
        
    }
}

const user = new SmartHike('Vili');
console.log(user.addGoal('Musala', 2925));
console.log(user.addGoal('Rui', 1706));
console.log(user.hike('Musala', 8, 'hard'));
console.log(user.hike('Rui', 3, 'easy'));
console.log(user.hike('Everest', 12, 'hard'));




