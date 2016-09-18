import {MessagePrefix} from './message-prefix';

export interface IPrefixCategory {
    id?: number;
    name?: string;
    creationDate?: Date;

    messagePrefixes?: Array<MessagePrefix>;
}

export class PrefixCategory {
    id: number;
    name: string;
    creationDate: Date;

    messagePrefixes: Array<MessagePrefix>;

    constructor(obj?: IPrefixCategory) {
        this.id = obj && obj.id ? obj.id : 0;
        this.name = obj && obj.name ? obj.name : '';
        this.creationDate = obj && obj.creationDate ? obj.creationDate : new Date();

        this.messagePrefixes = obj && obj.messagePrefixes ? obj.messagePrefixes : null;
    }
}