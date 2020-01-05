import Company from '../models/company';
import cuid from 'cuid';

export function getCompanies(req, res) {
  Company.find().exec((err, data) => {
    if (err) {
      return res.status(500).send(err);
    }
    res.json({ companies: data });
  });
}

export function pizza(req, res) {
  res.jason([

    {
      name: "Cheese Pizza",
      category: ["popular"],
      description: "classic marinara sauce top, mozzarella cheese",
      image: ""
    },
    {
      name: "Pepperoni Pizza",
      category: ["popular", "meat"],
      description: "mozzarella cheese, pepperoni",
      image: ""
    },
    {
      name: "Chicago Pizza",
      category: ["veggie"],
      description: "deep-dish crust, cheese, fresh tomato sauce",
      image: ""
    },
    {
      name: "White Pizza",
      category: ["veggie"],
      description: "garlic, ricotta, mozzarella",
      image: ""
    },
    {
      name: "Salad Pizza",
      category: ["veggie"],
      description: "romaine, cucumber, tomatoes, feta, olive,Greek dressing",
      image: ""
    }
  ])
}

export function getCompany(req, res) {
  //res.send({message:'Get Message'});
  Company.findOne({ cuid: req.params.id }).exec((err, data) => {
    if (err) {
      return res.status(500).send(err);
    }
    res.json({ company: data });
  });
}

export function addCompany(req, res) {
  console.log('params:', req.body);
  var param = req.body;
  const newCompany = new Company();
  //set schema
  newCompany.cuid = cuid();
  newCompany.name = param.name;
  newCompany.phone = param.phone;
  newCompany.email = param.email;
  newCompany.website = param.website;
  newCompany.type = param.type;
  newCompany.save((err, data) => {
    if (err) {
      return res.status(500).send(err);
    }
    return res.json({ Company: data });
  });
}

export function updateCompany(req, res) {
  var param = req.body;
  Company.findOne({ cuid: param.id }).exec((err, data) => {
    if (err) {
      return res.staus(500).send(err);
    }

    if (param.name)
      data.name = param.name;
    if (param.phone)
      data.phone = param.phone;
    if (param.email)
      data.email = param.email;
    if (param.website)
      data.website = param.website;
    if (param.type)
      data.type = param.type;
    data.save((err, data) => {
      if (err) {
        return res.status(500).send(err);
      }
      return res.send({ message: data.name + ' Updated' });
    });
  });
}

export function deleteCompany(req, res) {
  Company.findOne({ cuid: req.params.id }).exec((err, data) => {
    if (err) {
      return res.status(500).send(err);
    }
    var name = data.name;
    data.remove(() => {
      res.send({ message: name + ' Deleted' });
    });
  });
}