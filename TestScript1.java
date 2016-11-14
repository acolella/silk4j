import com.borland.silktest.jtf.Desktop;
import com.borland.silktest.jtf.SilkTestSuite;
import com.microfocus.silktest.*;
import com.borland.silk.*;
import com.borland.silktest.jtf.dll.*;
import org.junit.Before;
import com.borland.silktest.jtf.BrowserBaseState;
import com.borland.silktest.jtf.common.types.MouseButton;
import com.borland.silktest.jtf.common.types.Point;
import com.borland.silktest.jtf.xbrowser.DomTextField;

import org.junit.Test;

public class TestScript1 {

	private Desktop desk = new Desktop();

	@Before
	public void baseState() {
		BrowserBaseState baseState = new BrowserBaseState();
		baseState.execute(desk);
	
	}
	@Test
	public void mainScript() {
		desk.<DomTextField> find("//BrowserApplication//BrowserWindow//INPUT[@name='username']")
		.typeKeys("antonio.silva");
	}
}