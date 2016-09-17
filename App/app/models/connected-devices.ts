import {User} from './user';

export class ConnectedDevices {
    Id: number;
    UserId: number;
    DeviceId: string;
    ConfirmationCode: string;
    User: User;
}