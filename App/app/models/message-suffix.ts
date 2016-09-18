import {Message} from './message';
import {SuffixCategory} from './suffix-category'

export interface IMessageSuffix {
    id?: number;
    name?: string;
    creationDate?: Date;
    suffixCategoryId?: number;

    messages?: Array<Message>;
    suffixCategory?: SuffixCategory;
}

export class MessageSuffix {
    id: number;
    name: string;
    creationDate: Date;
    suffixCategoryId: number;

    messages: Array<Message>;
    suffixCategory: SuffixCategory;

    constructor(obj?: IMessageSuffix) {
        this.id = obj && obj.id ? obj.id : 0;
        this.name = obj && obj.name ? obj.name : '';
        this.creationDate = obj && obj.creationDate ? obj.creationDate : new Date();
        this.suffixCategoryId = obj && obj.suffixCategoryId ? obj.suffixCategoryId : null;

        this.messages = obj && obj.messages ? obj.messages : null;
        this.suffixCategory = obj && obj.suffixCategory ? obj.suffixCategory : null;
    }
}