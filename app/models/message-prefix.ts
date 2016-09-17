import {Message} from './message';
import {PrefixCategory} from './prefix-category'

export interface IMessagePrefix {
    Id?: number;
    Name?: string;
    CreationDate?: Date;
    PrefixCategoryId?: number;

    Messages?: Array<Message>;
    PrefixCategory?: PrefixCategory;
}

export class MessagePrefix {
    Id: number = 0;
    Name: string;
    CreationDate: Date;
    PrefixCategoryId: number;

    Messages: Array<Message>;
    PrefixCategory: PrefixCategory;

    constructor(obj?: IMessagePrefix) {
        this.Id = obj && obj.Id ? obj.Id : 0;
        this.Name = obj && obj.Name ? obj.Name : '';
        this.CreationDate = obj && obj.CreationDate ? obj.CreationDate : new Date();
        this.PrefixCategoryId = obj && obj.PrefixCategoryId ? obj.PrefixCategoryId : null;

        this.Messages = obj && obj.Messages ? obj.Messages : null;
        this.PrefixCategory = obj && obj.PrefixCategory ? obj.PrefixCategory : null;
    }
}