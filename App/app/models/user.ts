import {Message} from './message';

export interface IUser {
    id?: number;
    email?: string;
    nickName?: string;
    fullName?: string;
    phoneNumber?: string;
    registerDate?: Date;
    //ConnectedDevices?: Array<ConnectedDevice>;
    messagesFrom?: Array<Message>;
    messagesTo?: Array<Message>;
}

export class User {
    id: number;
    email: string;
    nickName: string;
    fullName: string;
    phoneNumber: string;
    registerDate: Date;
    //connectedDevices: Array<ConnectedDevice>;
    messagesFrom: Array<Message>;
    messagesTo: Array<Message>;

    constructor(user?: IUser) {
        this.id = user && user.id ? user.id : 0;
        this.email = user && user.email ? user.email : '';
        this.nickName = user && user.nickName ? user.nickName : '';
        this.fullName = user && user.fullName ? user.fullName : '';
        this.phoneNumber = user && user.phoneNumber ? user.phoneNumber : '';
        this.registerDate = user && user.registerDate ? user.registerDate : new Date(Date.now());
        //this.connectedDevices = user && user.connectedDevices || null;
        this.messagesFrom = user && user.messagesFrom ? user.messagesFrom : null;
        this.messagesTo = user && user.messagesTo ? user.messagesTo : null;
    }
}