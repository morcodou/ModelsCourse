class ClientViewModel {
  constructor(data) {
    this.id = data.id;
    this.name = data.name;
    this.contact = data.contact;
    this.phone = data.phone;
  }
}


let client = new ClientViewModel({
  id: 1,
  name: "Bob",
  contact: "phill",
  phone: "6673-993"
});

client.id = 12;
client.id = "string data";
