
<p><u><strong>Description</strong></u></p>
<p>The &lt;pWC_Order Type&gt; require to be created as the&nbsp;Order Type in the acumatica sales order upon exporting to the AC from WC</p>
<p><u><strong>Prerequisites</strong></u></p>
<p>1. User has access to the ERP application<br />2. WooCommerce Connector is configured</p>
<p>3. Customer has access to the WooCommerce Web Application</p>
<p>&nbsp;</p>
<p><u><strong>Detailed Steps to Test</strong></u></p>
<p>&nbsp;</p>
<p>1. Open the WC Client app</p>
<p>2. Login to the WooCommerce web application as the Registered Customer</p>
<p>3. Add some items to the cart</p>
<p>4. Select the payment method and proceed, Then place the order</p>
<p>5. Prepare and Process the payment</p>
<p>Commerce &gt; Processes</p>
<p>6. Open the payment record from Sync History</p>
<p>Commerce &gt; Inquiries</p>
<p>7. Validate the&nbsp;&lt;pWC_Order Type&gt; in the Order Type field in the acumatica</p>
<p>&nbsp;</p>
<p><u><strong>Expected Results</strong></u></p>
<p>The AC Sales Order 'Order type value should be equal with the&nbsp;&lt;pWC_Order Type&gt;</p>
<p><u><strong>Test Data</strong></u></p>
<div><u><strong>&lt;pWC_Order Type&gt;</strong></u></div>