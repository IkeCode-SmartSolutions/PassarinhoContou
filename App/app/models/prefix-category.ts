import {MessagePrefix} from './message-prefix';

export interface IPrefixCategory {
    Id?: number;
    Name?: string;
    CreationDate?: Date;

    MessagePrefixes?: Array<MessagePrefix>;
}

export class PrefixCategory {
    Id: number;
    Name: string;
    CreationDate: Date;

    MessagePrefixes: Array<MessagePrefix>;

    constructor(obj?: IPrefixCategory) {
        this.Id = obj && obj.Id ? obj.Id : 0;
        this.Name = obj && obj.Name ? obj.Name : '';
        this.CreationDate = obj && obj.CreationDate ? obj.CreationDate : new Date();

        this.MessagePrefixes = obj && obj.MessagePrefixes ? obj.MessagePrefixes : null;
    }
}