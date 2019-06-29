import React, { useState, useEffect } from 'react';
import MyModal from '../Modals/MyModal';
import { default as AccountList } from './Components/List';
import { default as Add } from './Components/Add';
import { default as Update } from './Components/Update';
import { default as ChangePassword } from './Components/ChangePassword';
import { default as Details } from './Components/Details';
import { Segment, ButtonGroup, Button, Confirm } from 'semantic-ui-react';
import { default as Message } from '../Base/Messages/Message';

let selectedRows = null;

export default function Accounts() {
  const [modalOpen, setModalOpen] = useState(false);
  const [modal, setModal] = useState({});
  const [message, setMessage] = useState(null);
  const [confirm, setConfirm] = useState({
    open: false,
    content: false,
    callback: null
  });
  let tableRef = React.createRef();
  const handleSelectionChange = (rows) => {
    selectedRows = rows;
  };
  const checkSelection = () => {
    return !selectedRows || selectedRows.length === 0;
  }
  const handleConfirm = () => {
    if (confirm.callback) {
      confirm.callback();
    }
    setConfirm({ open: false });
  }
  const handleOpenDetails = () => {
    if (checkSelection()) {
      return;
    }
    setModalOpen(true);
    setModal({
      com: <Details id={selectedRows[0].id} />,
      expandLink: `/hr/accounts/details/${selectedRows[0].id}`,
      header: `ACCOUNT_DETAILS`
    });
  }
  const handleOpenAdd = () => {
    setModalOpen(true);
    setModal({
      com: <Add />,
      expandLink: `/hr/accounts/add`,
      header: `ACCOUNT_DETAILS`
    });
  }

  const handleOpenUpdate = () => {
    if (checkSelection()) {
      return;
    }
    setModalOpen(true);
    setModal({
      com: <Update id={selectedRows[0].id} />,
      expandLink: `/hr/accounts/details/${selectedRows[0].id}`,
      header: `ACCOUNT_DETAILS`
    });
  }

  return (
    <Segment>
      <ButtonGroup>
        <Button color="green" onClick={handleOpenAdd} >Add</Button>
        <Button primary onClick={handleOpenDetails}>Details</Button>
        <Button primary onClick={handleOpenUpdate}>Update</Button>
        <Button primary>Change Password</Button>
        <Button primary>Block</Button>
        <Button primary>Unblock</Button>
        <Button color="red">Delete</Button>
      </ButtonGroup>
      <hr />
      <AccountList tableRef={tableRef} onSelectionChange={handleSelectionChange}
        options={{
          debounceInterval: 1000,
          selection: true,
          scroll: true
        }} />
      <MyModal open={modalOpen} component={modal.com} onClose={() => setModalOpen(false)} expandable={modal.expandLink} header={modal.header} />
      <Confirm open={confirm.open} content={confirm.content} onCancel={() => setConfirm({ open: false })} onConfirm={handleConfirm} />
    </Segment>
  )
}
