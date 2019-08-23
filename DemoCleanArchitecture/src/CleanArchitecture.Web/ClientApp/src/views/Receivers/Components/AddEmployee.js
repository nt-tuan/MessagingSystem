import React from 'react';
import Selection from '../../Employees/Components/Selection';
import { Label, FormGroup } from 'semantic-ui-react'
function AddCustomer() {
  [employee, setEmployee] = useState(undefined);
  return (<FormGroup>
    <Label>EMPLOYEE</Label>
    <Selection value={employee} />
    <Button>ADD</Button>
  </FormGroup>);
}
