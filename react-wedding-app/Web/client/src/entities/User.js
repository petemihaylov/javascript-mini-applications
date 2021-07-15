export default class User {

    constructor(id, username, passwordHash, passwordSalt, firstName, lastName){
        this.id = id;
        this.username = username;
        this.passwordHash = passwordHash;
        this.passwordSalt = passwordSalt;
        this.firstName = firstName;
        this.lastName = lastName;
    }

}