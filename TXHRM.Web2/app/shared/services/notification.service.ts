
import { Injectable } from '@angular/core';
import { ToastModule, ToastOptions } from 'ng2-toastr/ng2-toastr';
import { ToastsManager } from 'ng2-toastr/src/toast-manager';


@Injectable()
export class NotificationService {
    constructor(public toastr: ToastsManager) { }
    defaultOption: ToastOptions = {
        toastLife: 3000,
        dismiss: 'auto',
        positionClass: 'toast-top-right',
        maxShown: 5,
        animate: 'fade',
        newestOnTop: false,
        showCloseButton: true,
        enableHTML: true,
        messageClass: '',
        titleClass:''
    };

    public ShowSuccess(message: string, title?: string, option?: object) {
        if (option!==null) {
            this.toastr.success(message, title, option);
        } else {
            this.toastr.success(message, title, this.defaultOption);
        }
    }
    public ShowError(message: string, title?: string, option?: object) {
        if (option !== null) {
            this.toastr.error(message, title, option);
        } else {
            this.toastr.error(message, title, this.defaultOption);
        }
    }
    public ShowWarning(message: string, title?: string, option?: object) {
        if (option !== null) {
            this.toastr.warning(message, title, option);
        } else {
            this.toastr.warning(message, title, this.defaultOption);
        }
    }
    public ShowInfo(message: string, title?: string, option?: object) {
        if (option !== null) {
            this.toastr.info(message, title, option);
        } else {
            this.toastr.info(message, title, this.defaultOption);
        }
    }
}
