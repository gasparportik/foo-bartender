package foobartender;

import org.eclipse.core.commands.ExecutionEvent;
import org.eclipse.jface.window.Window;
import org.eclipse.swt.graphics.Point;
import org.eclipse.swt.widgets.Shell;
import org.eclipse.ui.application.ActionBarAdvisor;
import org.eclipse.ui.application.IActionBarConfigurer;
import org.eclipse.ui.application.IWorkbenchWindowConfigurer;
import org.eclipse.ui.application.WorkbenchWindowAdvisor;
import org.eclipse.ui.handlers.HandlerUtil;

public class ApplicationWorkbenchWindowAdvisor extends WorkbenchWindowAdvisor {
	Shell shell;

	public ApplicationWorkbenchWindowAdvisor(
			IWorkbenchWindowConfigurer configurer) {
		super(configurer);
		ExecutionEvent e = new ExecutionEvent();
		shell = new Shell();
		LoginDialog loginDialog = new LoginDialog(shell);
		
		
		if (loginDialog.open() == Window.OK && loginDialog.getUsername().matches("root") && loginDialog.getPassword().matches("devel")) {
			System.out.println("Login successful.");
		} else {
			HandlerUtil.getActiveWorkbenchWindow(e).close();
		}
	}

	public ActionBarAdvisor createActionBarAdvisor(
			IActionBarConfigurer configurer) {
		return new ApplicationActionBarAdvisor(configurer);
	}

	public void preWindowOpen() {
		IWorkbenchWindowConfigurer configurer = getWindowConfigurer();
		configurer.setInitialSize(new Point(600, 400));
		configurer.setShowCoolBar(true);
		configurer.setShowStatusLine(false);
	}

}
