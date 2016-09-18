import {MessageSuffix} from './message-suffix';

export interface ISuffixCategory {
    id?: number;
    name?: string;
    creationDate?: Date;

    messageSuffixes?: Array<MessageSuffix>;
}

export class SuffixCategory {
    id: number;
    name: string;
    creationDate: Date;

    messageSuffixes: Array<MessageSuffix>;

    constructor(obj?: ISuffixCategory) {
        this.id = obj && obj.id ? obj.id : 0;
        this.name = obj && obj.name ? obj.name : '';
        this.creationDate = obj && obj.creationDate ? obj.creationDate : new Date();

        this.messageSuffixes = obj && obj.messageSuffixes ? obj.messageSuffixes : null;
    }
}