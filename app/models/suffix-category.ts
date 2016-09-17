import {MessageSuffix} from './message-suffix';

export interface ISuffixCategory {
    Id?: number;
    Name?: string;
    CreationDate?: Date;

    MessageSuffixes?: Array<MessageSuffix>;
}

export class SuffixCategory {
    Id: number;
    Name: string;
    CreationDate: Date;

    MessageSuffixes: Array<MessageSuffix>;

    constructor(obj?: ISuffixCategory) {
        this.Id = obj && obj.Id ? obj.Id : 0;
        this.Name = obj && obj.Name ? obj.Name : '';
        this.CreationDate = obj && obj.CreationDate ? obj.CreationDate : new Date();

        this.MessageSuffixes = obj && obj.MessageSuffixes ? obj.MessageSuffixes : null;
    }
}