import {User} from './user';

import { MessagePrefix } from './message-prefix'
import { MessageSuffix } from './message-suffix'

export interface IMessage {
    id?: number;
    fromUserId?: number;
    toUserId?: number;
    status?: number;
    selectedPrefixId?: number;
    selectedSuffixId?: number;
    messageType?: number;
    languageId?: number;
    creationDate?: Date;

    messagePrefix?: MessagePrefix;
    messageSuffix?: MessageSuffix;
    fromUser?: User;
    toUser?: User;
}

export class Message {
    id: number;
    fromUserId: number;
    toUserId: number;
    status: number;
    selectedPrefixId: number;
    selectedSuffixId: number;
    messageType: number;
    languageId: number;
    creationDate: Date;

    messagePrefix: MessagePrefix;
    messageSuffix: MessageSuffix;
    fromUser: User;
    toUser: User;

    constructor(message?: IMessage) {
        this.id = message && message.id || 0;
        this.fromUserId = message && message.fromUserId || 0;
        this.toUserId = message && message.toUserId || 0;
        this.status = message && message.status || 0;
        this.selectedPrefixId = message && message.selectedPrefixId || 0;
        this.selectedSuffixId = message && message.selectedSuffixId || 0;
        this.messageType = message && message.messageType || 0;
        this.languageId = message && message.languageId || 0;
        this.creationDate = message && message.creationDate || new Date(Date.now());

        this.messagePrefix = message && message.messagePrefix || null;
        this.messageSuffix = message && message.messageSuffix || null;
        this.fromUser = message && message.fromUser || null;
        this.toUser = message && message.toUser || null;
    }
}