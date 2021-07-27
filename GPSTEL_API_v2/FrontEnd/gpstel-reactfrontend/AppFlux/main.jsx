import React from 'react';
import router from './routes';
import 'bootstrap';
router.run(function (Handler) {
	React.render(<Handler />, document.getElementById('app'));
});