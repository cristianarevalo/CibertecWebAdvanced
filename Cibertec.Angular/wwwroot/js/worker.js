var self = this; //cambiando de ambito

self.onmessage = function (message) { //funcion anonima

    var values = message.data.split(',');
    var member = {
        member_no: values[0],
        lastname: values[1],
        firstname: values[2],
        middleinitial: values[3],
        street: values[4],
        city: values[5],
        state_prov: values[6],
        country: values[7],
        mail_code: values[8],
        phone_no: values[9],
        issue_dt: values[10],
        expr_dt: values[11],
        corp_no: values[12],
        prev_balance: values[13],
        curr_balance: values[14],
        member_code: values[15]
    };

    return self.postMessage(member); //retornando un mensaje
}