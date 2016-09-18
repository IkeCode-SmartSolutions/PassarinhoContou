import {Message} from './message';
import {PrefixCategory} from './prefix-category'

export interface IMessagePrefix {
    id?: number;
    name?: string;
    creationDate?: Date;
    prefixCategoryId?: number;

    messages?: Array<Message>;
    prefixCategory?: PrefixCategory;
}

export class MessagePrefix {
    id: number = 0;
    name: string;
    creationDate: Date;
    prefixCategoryId: number;

    messages: Array<Message>;
    prefixCategory: PrefixCategory;

    constructor(obj?: IMessagePrefix) {
        this.id = obj && obj.id ? obj.id : 0;
        this.name = obj && obj.name ? obj.name : '';
        this.creationDate = obj && obj.creationDate ? obj.creationDate : new Date();
        this.prefixCategoryId = obj && obj.prefixCategoryId ? obj.prefixCategoryId : null;

        this.messages = obj && obj.messages ? obj.messages : null;
        this.prefixCategory = obj && obj.prefixCategory ? obj.prefixCategory : null;
    }
}