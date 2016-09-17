import {Message} from './message';

export interface IUser {
    Id?: number;
    Email?: string;
    NickName?: string;
    FullName?: string;
    PhoneNumber?: string;
    RegisterDate?: Date;
    //ConnectedDevices?: Array<ConnectedDevice>;
    MessagesFrom?: Array<Message>;
    MessagesTo?: Array<Message>;
}

export class User {
    Id: number;
    Email: string;
    NickName: string;
    FullName: string;
    PhoneNumber: string;
    RegisterDate: Date;
    //ConnectedDevices: Array<ConnectedDevice>;
    MessagesFrom: Array<Message>;
    MessagesTo: Array<Message>;

    constructor(user?: IUser) {
        this.Id = user && user.Id ? user.Id : 0;
        this.Email = user && user.Email ? user.Email : '';
        this.NickName = user && user.NickName ? user.NickName : '';
        this.FullName = user && user.FullName ? user.FullName : '';
        this.PhoneNumber = user && user.PhoneNumber ? user.PhoneNumber : '';
        this.RegisterDate = user && user.RegisterDate ? user.RegisterDate : new Date();
        //this.ConnectedDevices = user && user.ConnectedDevices || null;
        this.MessagesFrom = user && user.MessagesFrom ? user.MessagesFrom : null;
        this.MessagesTo = user && user.MessagesTo ? user.MessagesTo : null;
    }
}