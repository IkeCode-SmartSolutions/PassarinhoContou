import {Message} from './message';
import {SuffixCategory} from './suffix-category'

export interface IMessageSuffix {
    Id?: number;
    Name?: string;
    CreationDate?: Date;
    SuffixCategoryId?: number;

    Messages?: Array<Message>;
    SuffixCategory?: SuffixCategory;
}

export class MessageSuffix {
    Id: number;
    Name: string;
    CreationDate: Date;
    SuffixCategoryId: number;

    Messages: Array<Message>;
    SuffixCategory: SuffixCategory;

    constructor(obj?: IMessageSuffix) {
        this.Id = obj && obj.Id ? obj.Id : 0;
        this.Name = obj && obj.Name ? obj.Name : '';
        this.CreationDate = obj && obj.CreationDate ? obj.CreationDate : new Date();
        this.SuffixCategoryId = obj && obj.SuffixCategoryId ? obj.SuffixCategoryId : null;

        this.Messages = obj && obj.Messages ? obj.Messages : null;
        this.SuffixCategory = obj && obj.SuffixCategory ? obj.SuffixCategory : null;
    }
}