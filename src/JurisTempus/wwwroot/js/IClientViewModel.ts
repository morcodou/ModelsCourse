interface IClientViewModel {
  id: number;
  name: string;
  contact: string;
  phone: string;
}


function showClient(vm: IClientViewModel) {
  console.log(vm);
}

showClient({
  id: 1,
  name: "Bob",
  contact: "phill",
  phone: "6673-993"
}); 
