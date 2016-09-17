import {User} from './user';

import { MessagePrefix } from './message-prefix'
import { MessageSuffix } from './message-suffix'

export interface IMessage {
    Id?: number;
    FromUserId?: number;
    ToUserId?: number;
    Status?: number;
    SelectedPrefixId?: number;
    SelectedSuffixId?: number;
    MessageType?: number;
    LanguageId?: number;
    CreationDate?: Date;

    MessagePrefix?: MessagePrefix;
    MessageSuffix?: MessageSuffix;
    FromUser?: User;
    ToUser?: User;
}

export class Message {
    Id: number;
    FromUserId: number;
    ToUserId: number;
    Status: number;
    SelectedPrefixId: number;
    SelectedSuffixId: number;
    MessageType: number;
    LanguageId: number;
    CreationDate: Date;

    MessagePrefix: MessagePrefix;
    MessageSuffix: MessageSuffix;
    FromUser: User;
    ToUser: User;

    constructor(message?: IMessage) {
        this.Id = message && message.Id || 0;
        this.FromUserId = message && message.FromUserId || 0;
        this.ToUserId = message && message.ToUserId || 0;
        this.Status = message && message.Status || 0;
        this.SelectedPrefixId = message && message.SelectedPrefixId || 0;
        this.SelectedSuffixId = message && message.SelectedSuffixId || 0;
        this.MessageType = message && message.MessageType || 0;
        this.LanguageId = message && message.LanguageId || 0;
        this.CreationDate = message && message.CreationDate || new Date();

        this.MessagePrefix = message && message.MessagePrefix || null;
        this.MessageSuffix = message && message.MessageSuffix || null;
        this.FromUser = message && message.FromUser || null;
        this.ToUser = message && message.ToUser || null;
    }
}